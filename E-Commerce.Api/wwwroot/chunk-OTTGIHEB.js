import{a as O}from"./chunk-7UXYMRK4.js";import{a as S}from"./chunk-LSPEVGDF.js";import{o as M,q as w}from"./chunk-FWUE3TP4.js";import{Cb as _,Eb as g,Mc as x,Nb as m,Ob as I,Pb as C,Qc as k,Uc as l,Va as i,Wa as h,Wb as u,Yb as v,da as s,mb as f,nb as y,ob as c,ub as a,vb as d,wb as p}from"./chunk-AWDU22X2.js";var B=e=>["/product-detials",e],z=e=>({"background-image":e});function j(e,t){if(e&1&&(a(0,"div",6),m(1),d()),e&2){let b=g();i(),C(" EGP ",b.productPriceBefore,`
`)}}var E=(()=>{let t=class t{constructor(r,o){this.basketService=r,this.toastrService=o}clicked(){}AddToCart(){try{let r={ProductId:this.productId,Quantity:1,UnitPrice:this.productPrice,Total:this.productPrice};this.basketService.addItem(r),this.toastrService.success("product added",`${this.productName} Added successfully`,{enableHtml:!0,closeButton:!0}),this.basketService.cart$.subscribe(o=>{})}catch{}}};t.\u0275fac=function(o){return new(o||t)(h(O),h(S))},t.\u0275cmp=s({type:t,selectors:[["app-inner-card"]],inputs:{productName:"productName",productPrice:"productPrice",productImage:"productImage",productId:"productId",productPriceBefore:"productPriceBefore"},standalone:!0,features:[u],decls:9,vars:9,consts:[[1,"card","h-[400px]","w-full","flex","flex-col","gap-10",3,"click"],[1,"z-10","w-full","h-64","p-2","bg-center","bg-cover",2,"background-position","center","background-size","contain",3,"routerLink","ngStyle"],[1,"text-xl","font-inter","mt-5","mb-5"],["class","mb-5 text-2lx text-red-600 line-through float-end",4,"ngIf"],[1,"mb-5","text-lg"],["type","button",1,"text-gray-900","bg-white","border-2","border-gray-300","focus:outline-none","hover:bg-[#FDEDE1]","hover:border-[#FDEDE1]","focus:ring-4","focus:ring-gray-100","font-medium","rounded-full","text-sm","w-full","px-5","py-2.5","me-2","mb-2","dark:bg-gray-800","dark:text-white","dark:border-gray-600","dark:hover:bg-gray-700","dark:hover:border-gray-600","dark:focus:ring-gray-700",3,"click"],[1,"mb-5","text-2lx","text-red-600","line-through","float-end"]],template:function(o,n){o&1&&(a(0,"div",0),_("click",function(){return n.clicked()}),p(1,"div",1),d(),a(2,"div",2),m(3),d(),f(4,j,2,1,"div",3),a(5,"div",4),m(6),d(),a(7,"button",5),_("click",function(F){return F.stopPropagation()})("click",function(){return n.AddToCart()}),m(8,` Add To Cart
`),d()),o&2&&(i(),c("routerLink",v(5,B,n.productId))("ngStyle",v(7,z,"url("+n.productImage+")")),i(2),I(n.productName),i(),c("ngIf",n.productPriceBefore!=n.productPrice),i(2),C("EGP ",n.productPrice,""))},dependencies:[l,x,k,w,M],styles:['.card[_ngcontent-%COMP%]{box-shadow:0 10px 10px #00000036;background:#fff;display:flex;border-radius:20px;justify-content:center;position:relative;transition:all .4s}.card[_ngcontent-%COMP%]:before{content:"--------Show Details--------";letter-spacing:.2em;position:absolute;bottom:8px;left:20px;color:#333;font-size:.8em;font-weight:700}.card[_ngcontent-%COMP%]   div[_ngcontent-%COMP%]{width:100%;height:100%;border-radius:20px;box-shadow:0 0 10px #00000036;cursor:pointer;z-index:10;transition:all .3s;background-color:#fff}.card[_ngcontent-%COMP%]:hover   div[_ngcontent-%COMP%]{transform:translateY(-31px)}.custom-toast-success[_ngcontent-%COMP%]   .toast-title[_ngcontent-%COMP%]{color:#28a745;background-color:#000;font-weight:700}.custom-toast-success[_ngcontent-%COMP%]   .toast-message[_ngcontent-%COMP%]{color:#155724}.custom-toast-error[_ngcontent-%COMP%]   .toast-title[_ngcontent-%COMP%]{color:#dc3545;font-weight:700}.custom-toast-error[_ngcontent-%COMP%]   .toast-message[_ngcontent-%COMP%]{color:#721c24}']});let e=t;return e})();function A(e,t){if(e&1&&p(0,"span",4),e&2){let b=g();y("data-content","Save "+b.product._price._discount+"%")}}var D=(()=>{let t=class t{};t.\u0275fac=function(o){return new(o||t)},t.\u0275cmp=s({type:t,selectors:[["app-out-card"]],inputs:{product:"product"},standalone:!0,features:[u],decls:4,vars:6,consts:[[1,"container","h-fit","w-full"],[1,"card_box","relative","flex","h-[250px]","w-full"],["class","absolute z-20",4,"ngIf"],[1,"h-3/4","w-full","self-center",3,"productName","productPrice","productImage","productId","productPriceBefore"],[1,"absolute","z-20"]],template:function(o,n){o&1&&(a(0,"div",0)(1,"div",1),f(2,A,1,1,"span",2),p(3,"app-inner-card",3),d()()),o&2&&(i(2),c("ngIf",n.product._price._discount!=0),i(),c("productName",n.product._name)("productPrice",n.product._price._total)("productImage",n.product.masterImage)("productId",n.product.id)("productPriceBefore",n.product._price._price))},dependencies:[E,l,x],styles:['.container[_ngcontent-%COMP%]{display:flex;align-items:center;justify-content:center}.card_box[_ngcontent-%COMP%]{border-radius:20px;background:linear-gradient(170deg,#3a38389f,#1f1f1f);position:relative;box-shadow:0 25px 50px #0000008c;cursor:pointer;transition:all .3s}.card_box[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]{position:absolute;overflow:hidden;width:150px;height:150px;top:-10px;left:-10px;display:flex;align-items:center;justify-content:center}.card_box[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]:before{content:attr(data-content);position:absolute;width:150%;height:40px;background-image:linear-gradient(45deg,#ffc59a,#fdede1 51%,#ffc497);transform:rotate(-45deg) translateY(-20px);display:flex;align-items:center;justify-content:center;color:#1d1616;font-weight:600;letter-spacing:.1em;text-transform:uppercase;box-shadow:0 5px 10px #0000003b}.card_box[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]:after{content:"";position:absolute;width:10px;bottom:0;left:0;height:10px;z-index:-1;box-shadow:140px -140px #cc3f47;background-image:linear-gradient(45deg,#ff512f,#f09819 51%,#ff512f)}']});let e=t;return e})();var X=(()=>{let t=class t{};t.\u0275fac=function(o){return new(o||t)},t.\u0275cmp=s({type:t,selectors:[["app-card"]],inputs:{product:"product"},standalone:!0,features:[u],decls:1,vars:1,consts:[[1,"block","pt-20","w-[400px]",3,"product"]],template:function(o,n){o&1&&p(0,"app-out-card",0),o&2&&c("product",n.product)},dependencies:[D,l]});let e=t;return e})();export{X as a};