import{a as f,b as _,r as o}from"./chunk-FCALHRBG.js";import{V as l,_ as h,g as c,gb as P,o as g}from"./chunk-AWDU22X2.js";var d=class{};var I=(()=>{let r=class r{constructor(){this.filter=new c({sortColumn:null,searchTerm:null,startPrice:null,endPrice:null,asend:null,categoryIds:null})}};r.\u0275fac=function(e){return new(e||r)},r.\u0275prov=l({token:r,factory:r.\u0275fac,providedIn:"root"});let i=r;return i})();var N=(()=>{let r=class r{constructor(t,e){this._http=t,this.filterService=e,this.Product=new d,this.file=P(null),this.files=new c([]),this.files$=this.files.asObservable(),this.uploudfiles=[],this._createProduct=o.localhosts.product.addProduct,this._updateProduct=o.localhosts.product.updateProducts,this._addMasterImage=o.localhosts.product.addMasterImage,this._addProductImages=o.localhosts.product.addProductImages,this._addComment=o.localhosts.product.postComment,this._addProductToCarsoul=o.localhosts.product.addProductToCarsoul,this._getAllProducts=o.localhosts.product.getAllProductsWithNumber,this._getSingleProduct=o.localhosts.product.getSingleProduct,this._getProductMasterImage=o.localhosts.product.getProductMasterImage,this._getproductImage=o.localhosts.product.getProductImage,this._getSpecialProducts=o.localhosts.product.getSpecialProducts,this._getAllReviews=o.localhosts.product.getAllReviews}CreateNewProduct(){let t=new f({"Content-Type":"application/json"});return this._http.post(this._createProduct,this.Product,{headers:t})}UpdateProduct(t){return this._http.put(this._updateProduct+t,this.Product)}AddMatserImage(t){let e=new FormData;return e.append("file",this.file()),e.append("ProductId",t),this._http.post(this._addMasterImage,e)}AddProductImages(t,e){return this._http.post(this._addProductImages+e,t)}AddComment(t){return this._http.post(this._addComment,t)}AddProductToCarsoul(t,e){return console.log(this._addProductToCarsoul+t+"/"+e),this._http.get(this._addProductToCarsoul+t+"/"+e)}GetAllProducts(t,e,a,n,u){console.log(a);let s=this.filterService.filter.value,p="";s.categoryIds&&s.categoryIds.forEach(b=>p+=`&categoryIds=${b}`);let m=this._getAllProducts+t+(s.searchTerm?`&searchTerm=${e}`:"")+(s.sortColumn?`&sortColumn=${a}`:"")+(s.startPrice?`&startPrice=${s.startPrice}`:"")+(s.endPrice?`&endPrice=${s.endPrice}`:"")+(s.asend?`&asend=${s.asend}`:"")+(s.categoryIds&&s.categoryIds.length!=0?p:"");return console.log(m),this._http.get(m)}GetSingleProduct(t){return this._http.get(this._getSingleProduct+t)}GetProductMasterImage(t){return this._http.get(this._getProductMasterImage+t,{responseType:"blob"})}getProductImage(t,e){return this._http.get(this._getproductImage+e+`/${t}`,{observe:"response",responseType:"blob"}).pipe(g(a=>{let n=a.headers.get("Content-Disposition"),u="default.jpg";if(n){let s=n.match(/filename="(.+)"/);s&&(u=s[1])}return{blob:a.body,fileName:u}}))}GetSpecialProducts(t){return this._http.get(this._getSpecialProducts+t)}GetAllReviews(){return this._http.get(this._getAllReviews)}};r.\u0275fac=function(e){return new(e||r)(h(_),h(I))},r.\u0275prov=l({token:r,factory:r.\u0275fac,providedIn:"root"});let i=r;return i})();export{d as a,I as b,N as c};