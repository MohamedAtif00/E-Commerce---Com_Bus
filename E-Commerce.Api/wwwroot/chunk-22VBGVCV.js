import{m as I}from"./chunk-2H2VCZ2E.js";import{r as i,s as v}from"./chunk-FCALHRBG.js";import{V as a,Wb as g,_ as s,da as l,hb as u,nb as C,pa as p,ra as c,sb as d,ub as h,vb as m,wb as f}from"./chunk-AWDU22X2.js";var A=(()=>{let n=class n{constructor(t){this.http=t,this._addCoupon=i.localhosts.coupon.addCoupon,this._getAllCoupons=i.localhosts.coupon.getAllCoupons,this._getCoupon=i.localhosts.coupon.getCouponByCode}getCoupons(){return this.http.genericGetAPIData(this._getAllCoupons)}GetCouponByCode(t){return this.http.genericGetAPIData(this._getCoupon+t)}addCoupon(t){return this.http.genericPostAPIData(this._addCoupon,t)}};n.\u0275fac=function(o){return new(o||n)(s(v))},n.\u0275prov=a({token:n,factory:n.\u0275fac,providedIn:"root"});let e=n;return e})();var B=(()=>{class e extends I{static \u0275fac=(()=>{let r;return function(o){return(r||(r=c(e)))(o||e)}})();static \u0275cmp=l({type:e,selectors:[["ChevronDownIcon"]],standalone:!0,features:[u,g],decls:2,vars:5,consts:[["width","14","height","14","viewBox","0 0 14 14","fill","none","xmlns","http://www.w3.org/2000/svg"],["d","M7.01744 10.398C6.91269 10.3985 6.8089 10.378 6.71215 10.3379C6.61541 10.2977 6.52766 10.2386 6.45405 10.1641L1.13907 4.84913C1.03306 4.69404 0.985221 4.5065 1.00399 4.31958C1.02276 4.13266 1.10693 3.95838 1.24166 3.82747C1.37639 3.69655 1.55301 3.61742 1.74039 3.60402C1.92777 3.59062 2.11386 3.64382 2.26584 3.75424L7.01744 8.47394L11.769 3.75424C11.9189 3.65709 12.097 3.61306 12.2748 3.62921C12.4527 3.64535 12.6199 3.72073 12.7498 3.84328C12.8797 3.96582 12.9647 4.12842 12.9912 4.30502C13.0177 4.48162 12.9841 4.662 12.8958 4.81724L7.58083 10.1322C7.50996 10.2125 7.42344 10.2775 7.32656 10.3232C7.22968 10.3689 7.12449 10.3944 7.01744 10.398Z","fill","currentColor"]],template:function(t,o){t&1&&(p(),h(0,"svg",0),f(1,"path",1),m()),t&2&&(d(o.getClassNames()),C("aria-label",o.ariaLabel)("aria-hidden",o.ariaHidden)("role",o.role))},encapsulation:2})}return e})();export{A as a,B as b};