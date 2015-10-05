using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankForm.Models;

namespace TankForm.Logic
{
    public class TankStatusActions : IDisposable
    {
        public string TankStatusId { get; set; }

        private ProduktContext _db = new ProduktContext();

        public const string StatusSessionKey = "StatusId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            TankStatusId = GetCartId();

            var Tank = _db.TankStatus.SingleOrDefault(
                c => c.StatusId== TankStatusId
                && c.ProduktId == id);
            if (Tank == null)
            {
                // Create a new cart item if no cart item exists.                 
                Tank = new Tank
                {
                    TankId = Guid.NewGuid().ToString(),
                    ProduktId = id,
                    StatusId = TankStatusId,
                    Produkt = _db.Produkter.SingleOrDefault(
                     p => p.ProduktID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.TankStatus.Add(Tank);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                Tank.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[StatusSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[StatusSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[StatusSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[StatusSessionKey].ToString();
        }

        public List<Tank> GetCartItems()
        {
            TankStatusId = GetCartId();

            return _db.TankStatus.Where(
                c => c.StatusId == TankStatusId).ToList();
        }

        public decimal GetTotal()
        {
            TankStatusId = GetCartId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.TankStatus
                               where cartItems.StatusId == TankStatusId
                               select (int?)cartItems.Quantity *
                               cartItems.Produkt.Pris).Sum();
            return total ?? decimal.Zero;
        }
        public TankStatusActions GetCart(HttpContext context)
        {
            using (var cart = new TankStatusActions())
            {
                cart.TankStatusId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new TankForm.Models.ProduktContext())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<Tank> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Produkt.ProduktID == CartItemUpdates[i].ProduktId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProduktId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.ProduktId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProduktID)
        {
            using (var _db = new TankForm.Models.ProduktContext())
            {
                try
                {
                    var myItem = (from c in _db.TankStatus where c.StatusId== removeCartID && c.Produkt.ProduktID == removeProduktID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.TankStatus.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProduktID, int quantity)
        {
            using (var _db = new TankForm.Models.ProduktContext())
            {
                try
                {
                    var myItem = (from c in _db.TankStatus where c.StatusId == updateCartID && c.Produkt.ProduktID == updateProduktID select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            TankStatusId = GetCartId();
            var cartItems = _db.TankStatus.Where(
                c => c.TankId == TankStatusId);
            foreach (var cartItem in cartItems)
            {
                _db.TankStatus.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            TankStatusId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.TankStatus
                          where cartItems.StatusId == TankStatusId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProduktId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}