import{a as r,b as l}from"./chunk-KNFYFHY4.js";import{a as o,w as n}from"./chunk-Z643URES.js";import{V as h,_ as a}from"./chunk-74T7YZYI.js";var v=(()=>{let t=class t{constructor(e,i){this._http=e,this.auth=i,this._addDelivery=r.addDelivery,this._getAllDeliveries=r.getAllDeliveries,this._getShippingFee=r.getShippingFee,this.headers=new o().set("Authorization",this.auth.getToken())}AddDelivery(e){return this._http.genericPostAPIData(this._addDelivery,e,{headers:this.headers})}GetAllDeliveries(e){return this._http.genericPostAPIData(this._getAllDeliveries,e?{trackingNumbers:e}:null,{headers:this.headers})}GetShippingFee(e,i,p,c="Normal"){let d=new URLSearchParams({dropOffCity:e,pickupCity:i,cod:p.toString(),size:c}).toString();return this._http.genericGetAPIData(`${this._getShippingFee}?${d}`,{headers:this.headers})}};t.\u0275fac=function(i){return new(i||t)(a(n),a(l))},t.\u0275prov=h({token:t,factory:t.\u0275fac,providedIn:"root"});let s=t;return s})();export{v as a};