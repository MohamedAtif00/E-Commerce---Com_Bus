import{a as _,b as I,r}from"./chunk-MXDQPGS7.js";import{V as l,_ as p,g as c,hb as f,o as P}from"./chunk-74T7YZYI.js";var d=class{};var v=(()=>{let s=class s{constructor(){this.filter=new c({sortColumn:null,searchTerm:null,startPrice:null,endPrice:null,totalReviews:null,asend:null,categoryIds:null})}};s.\u0275fac=function(e){return new(e||s)},s.\u0275prov=l({token:s,factory:s.\u0275fac,providedIn:"root"});let i=s;return i})();var N=(()=>{let s=class s{constructor(t,e){this._http=t,this.filterService=e,this.Product=new d,this.file=f(null),this.files=new c([]),this.files$=this.files.asObservable(),this.uploudfiles=[],this._createProduct=r.localhosts.product.addProduct,this._updateProduct=r.localhosts.product.updateProducts,this._addMasterImage=r.localhosts.product.addMasterImage,this._addProductImages=r.localhosts.product.addProductImages,this._addComment=r.localhosts.product.postComment,this._addProductToCarsoul=r.localhosts.product.addProductToCarsoul,this._getAllProducts=r.localhosts.product.getAllProductsWithNumber,this._getSingleProduct=r.localhosts.product.getSingleProduct,this._getProductMasterImage=r.localhosts.product.getProductMasterImage,this._getproductImage=r.localhosts.product.getProductImage,this._getSpecialProducts=r.localhosts.product.getSpecialProducts,this._getAllReviews=r.localhosts.product.getAllReviews}CreateNewProduct(){let t=new _({"Content-Type":"application/json"});return this._http.post(this._createProduct,this.Product,{headers:t})}UpdateProduct(t){return this._http.put(this._updateProduct+t,this.Product)}AddMatserImage(t){let e=new FormData;return e.append("file",this.file()),e.append("ProductId",t),this._http.post(this._addMasterImage,e)}AddProductImages(t,e){return this._http.post(this._addProductImages+e,t)}AddComment(t){return this._http.post(this._addComment,t)}AddProductToCarsoul(t,e){return console.log(this._addProductToCarsoul+t+"/"+e),this._http.get(this._addProductToCarsoul+t+"/"+e)}GetAllProducts(t,e,a,n,u,h){console.log(a);let o=this.filterService.filter.value,m="";o.categoryIds&&o.categoryIds.forEach(b=>m+=`&categoryIds=${b}`);let g=this._getAllProducts+t+(o.searchTerm?`&searchTerm=${e}`:"")+(o.sortColumn?`&sortColumn=${a}`:"")+(o.startPrice?`&startPrice=${o.startPrice}`:"")+(o.endPrice?`&endPrice=${o.endPrice}`:"")+(o.asend?`&asend=${o.asend}`:"")+(o.totalReviews?`&totalReviews=${o.totalReviews}`:"")+(o.categoryIds&&o.categoryIds.length!=0?m:"");return console.log(g),this._http.get(g)}GetSingleProduct(t){return this._http.get(this._getSingleProduct+t)}GetProductMasterImage(t){return this._http.get(this._getProductMasterImage+t,{responseType:"blob"})}getProductImage(t,e){return this._http.get(this._getproductImage+e+`/${t}`,{observe:"response",responseType:"blob"}).pipe(P(a=>{let n=a.headers.get("Content-Disposition"),u="default.jpg";if(n){let h=n.match(/filename="(.+)"/);h&&(u=h[1])}return{blob:a.body,fileName:u}}))}GetSpecialProducts(t){return this._http.get(this._getSpecialProducts+t)}GetAllReviews(){return this._http.get(this._getAllReviews)}};s.\u0275fac=function(e){return new(e||s)(p(I),p(v))},s.\u0275prov=l({token:s,factory:s.\u0275fac,providedIn:"root"});let i=s;return i})();export{d as a,v as b,N as c};