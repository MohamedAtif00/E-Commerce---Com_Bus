import{V as r,g as c}from"./chunk-GRBNXT45.js";var o=class{constructor(){this.BasketItems=[]}};var u=(()=>{let a=class a{constructor(){this.basketKey="basketItems",this.cartSubject=new c(this.getInitialBasket()),this.cart$=this.cartSubject.asObservable()}getInitialBasket(){let e=localStorage.getItem(this.basketKey);return e?JSON.parse(e):new o}updateLocalStorage(e){localStorage.setItem(this.basketKey,JSON.stringify(e)),this.cartSubject.next(e)}addItem(e){let t=this.getInitialBasket(),s=t.BasketItems.findIndex(i=>i.ProductId===e.ProductId);s===-1?(e.Total=e.Quantity*e.UnitPrice,t.BasketItems.push(e)):(t.BasketItems[s].Quantity+=e.Quantity,t.BasketItems[s].Total=t.BasketItems[s].Quantity*t.BasketItems[s].UnitPrice),t.totalAmount=this.calculateTotalAmount(t.BasketItems),this.updateLocalStorage(t)}removeOneItem(e){let t=this.getInitialBasket(),s=t.BasketItems.findIndex(i=>i.ProductId===e);s!==-1&&(t.BasketItems[s].Quantity>1?(t.BasketItems[s].Quantity-=1,t.BasketItems[s].Total=t.BasketItems[s].Quantity*t.BasketItems[s].UnitPrice):t.BasketItems.splice(s,1),t.totalAmount=this.calculateTotalAmount(t.BasketItems),this.updateLocalStorage(t))}removeItem(e){let t=this.getInitialBasket(),s=t.BasketItems.findIndex(i=>i.ProductId===e);s!==-1&&(t.BasketItems.splice(s,1),t.totalAmount=this.calculateTotalAmount(t.BasketItems),this.updateLocalStorage(t))}clearBasket(){localStorage.removeItem(this.basketKey),this.cartSubject.next(new o)}calculateTotalAmount(e){return e.reduce((t,s)=>t+s.Total,0)}getBasketItems(){return this.getInitialBasket().BasketItems}};a.\u0275fac=function(t){return new(t||a)},a.\u0275prov=r({token:a,factory:a.\u0275fac,providedIn:"root"});let n=a;return n})();export{u as a};