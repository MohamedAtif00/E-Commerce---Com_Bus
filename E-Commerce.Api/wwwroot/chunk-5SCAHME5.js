import{e as m}from"./chunk-JU2YDHJK.js";import{j as g}from"./chunk-UQNWIDLI.js";import{Db as p,Vc as f,W as d,Xa as n,ea as r,fa as s,rb as c,rc as u,xa as a}from"./chunk-74T7YZYI.js";var y=(()=>{class e{el;ngModel;cd;config;variant="outlined";filled;constructor(o,t,i,l){this.el=o,this.ngModel=t,this.cd=i,this.config=l}ngAfterViewInit(){this.updateFilledState(),this.cd.detectChanges()}ngDoCheck(){this.updateFilledState()}onInput(){this.updateFilledState()}updateFilledState(){this.filled=this.el.nativeElement.value&&this.el.nativeElement.value.length||this.ngModel&&this.ngModel.model}static \u0275fac=function(t){return new(t||e)(n(a),n(g,8),n(u),n(m))};static \u0275dir=s({type:e,selectors:[["","pInputText",""]],hostAttrs:[1,"p-inputtext","p-component","p-element"],hostVars:4,hostBindings:function(t,i){t&1&&p("input",function(v){return i.onInput(v)}),t&2&&c("p-filled",i.filled)("p-variant-filled",i.variant==="filled"||i.config.inputStyle()==="filled")},inputs:{variant:"variant"}})}return e})(),j=(()=>{class e{static \u0275fac=function(t){return new(t||e)};static \u0275mod=r({type:e});static \u0275inj=d({imports:[f]})}return e})();export{y as a,j as b};