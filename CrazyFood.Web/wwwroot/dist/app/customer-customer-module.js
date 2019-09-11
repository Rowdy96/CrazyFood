(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["customer-customer-module"],{

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/customer-review/customer-review.component.html":
/*!***************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/customer-review/customer-review.component.html ***!
  \***************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>customer-review works!</p>\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/customer/customer.component.html":
/*!*************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/customer/customer.component.html ***!
  \*************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"panel panel-primary\">\n    <div class=\"panel-heading\">{{User.name}}</div>\n    <div class=\"panel-body\">\n      <h5>Phone: {{User.phone}}</h5>\n      <h5>Email: {{User.email}}</h5>\n      <h5>Address: {{User.address}}</h5>\n    </div>\n    <div class=\"panel-footer\">\n      <div class=\"btn-group btn-group-justified\">\n        <div class=\"btn-group\">\n          <a class=\"btn btn-primary\" routerLink=\"Reviews\">Reviews</a>\n        </div>\n        <div class=\"btn-group\">\n          <a class=\"btn btn-primary\" routerLink=\"OrderHistory\"> Order history</a>\n        </div>\n      </div>\n    </div>\n</div>\n\n<div class=\"panel panel-primary\">\n   <div class=\"panel-body\">\n      <router-outlet></router-outlet>\n   </div>\n</div>\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/order-history/order-history.component.html":
/*!***********************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/order-history/order-history.component.html ***!
  \***********************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngFor=\"let order of Orders\">\r\n  {{order.order.id}}\r\n  <div *ngFor=\"let item of order.orderItem\">\r\n    {{item.itemCount}} {{item.dish.dishName}} {{item.dish.price}} {{item.dish.menuCategory.restaurantId}}\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/customer/customer-review/customer-review.component.css":
/*!************************************************************************!*\
  !*** ./src/app/customer/customer-review/customer-review.component.css ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2N1c3RvbWVyL2N1c3RvbWVyLXJldmlldy9jdXN0b21lci1yZXZpZXcuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/customer/customer-review/customer-review.component.ts":
/*!***********************************************************************!*\
  !*** ./src/app/customer/customer-review/customer-review.component.ts ***!
  \***********************************************************************/
/*! exports provided: CustomerReviewComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerReviewComponent", function() { return CustomerReviewComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");


let CustomerReviewComponent = class CustomerReviewComponent {
    constructor() { }
    ngOnInit() {
    }
};
CustomerReviewComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-customer-review',
        template: __webpack_require__(/*! raw-loader!./customer-review.component.html */ "./node_modules/raw-loader/index.js!./src/app/customer/customer-review/customer-review.component.html"),
        styles: [__webpack_require__(/*! ./customer-review.component.css */ "./src/app/customer/customer-review/customer-review.component.css")]
    })
], CustomerReviewComponent);



/***/ }),

/***/ "./src/app/customer/customer-routing.module.ts":
/*!*****************************************************!*\
  !*** ./src/app/customer/customer-routing.module.ts ***!
  \*****************************************************/
/*! exports provided: CustomerRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerRoutingModule", function() { return CustomerRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _customer_customer_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./customer/customer.component */ "./src/app/customer/customer/customer.component.ts");
/* harmony import */ var _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./customer-review/customer-review.component */ "./src/app/customer/customer-review/customer-review.component.ts");
/* harmony import */ var _order_history_order_history_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./order-history/order-history.component */ "./src/app/customer/order-history/order-history.component.ts");






const routes = [
    {
        path: '',
        component: _customer_customer_component__WEBPACK_IMPORTED_MODULE_3__["CustomerComponent"],
        children: [
            {
                path: 'Reviews',
                component: _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_4__["CustomerReviewComponent"]
            },
            {
                path: 'OrderHistory',
                component: _order_history_order_history_component__WEBPACK_IMPORTED_MODULE_5__["OrderHistoryComponent"]
            }
        ]
    },
];
let CustomerRoutingModule = class CustomerRoutingModule {
};
CustomerRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
    })
], CustomerRoutingModule);



/***/ }),

/***/ "./src/app/customer/customer-service.service.ts":
/*!******************************************************!*\
  !*** ./src/app/customer/customer-service.service.ts ***!
  \******************************************************/
/*! exports provided: CustomerServiceService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerServiceService", function() { return CustomerServiceService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");



let CustomerServiceService = class CustomerServiceService {
    constructor(http) {
        this.http = http;
    }
    GetOrderHistory(userId) {
        return this.http.get('https://localhost:44303/api/Orders/GetAllOrdersOfUser/' + userId);
    }
};
CustomerServiceService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"] }
];
CustomerServiceService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
    })
], CustomerServiceService);



/***/ }),

/***/ "./src/app/customer/customer.module.ts":
/*!*********************************************!*\
  !*** ./src/app/customer/customer.module.ts ***!
  \*********************************************/
/*! exports provided: CustomerModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerModule", function() { return CustomerModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm2015/common.js");
/* harmony import */ var _customer_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./customer-routing.module */ "./src/app/customer/customer-routing.module.ts");
/* harmony import */ var _customer_customer_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./customer/customer.component */ "./src/app/customer/customer/customer.component.ts");
/* harmony import */ var _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./customer-review/customer-review.component */ "./src/app/customer/customer-review/customer-review.component.ts");
/* harmony import */ var _order_history_order_history_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./order-history/order-history.component */ "./src/app/customer/order-history/order-history.component.ts");







let CustomerModule = class CustomerModule {
};
CustomerModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [_customer_customer_component__WEBPACK_IMPORTED_MODULE_4__["CustomerComponent"], _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_5__["CustomerReviewComponent"], _order_history_order_history_component__WEBPACK_IMPORTED_MODULE_6__["OrderHistoryComponent"]],
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"],
            _customer_routing_module__WEBPACK_IMPORTED_MODULE_3__["CustomerRoutingModule"]
        ]
    })
], CustomerModule);



/***/ }),

/***/ "./src/app/customer/customer/customer.component.css":
/*!**********************************************************!*\
  !*** ./src/app/customer/customer/customer.component.css ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2N1c3RvbWVyL2N1c3RvbWVyL2N1c3RvbWVyLmNvbXBvbmVudC5jc3MifQ== */"

/***/ }),

/***/ "./src/app/customer/customer/customer.component.ts":
/*!*********************************************************!*\
  !*** ./src/app/customer/customer/customer.component.ts ***!
  \*********************************************************/
/*! exports provided: CustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerComponent", function() { return CustomerComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var src_app_user_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/user.service */ "./src/app/user.service.ts");
/* harmony import */ var src_app_Models_UserAC__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/Models/UserAC */ "./src/app/Models/UserAC.ts");




let CustomerComponent = class CustomerComponent {
    constructor(userSerVice) {
        this.userSerVice = userSerVice;
        this.User = new src_app_Models_UserAC__WEBPACK_IMPORTED_MODULE_3__["UserAC"]();
    }
    ngOnInit() {
        this.GetCurrentUser();
    }
    GetCurrentUser() {
        this.userSerVice.GetLoggedInUser().subscribe(res => {
            this.User = res;
        }, err => {
            console.log(err);
        });
    }
};
CustomerComponent.ctorParameters = () => [
    { type: src_app_user_service__WEBPACK_IMPORTED_MODULE_2__["UserService"] }
];
CustomerComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-customer',
        template: __webpack_require__(/*! raw-loader!./customer.component.html */ "./node_modules/raw-loader/index.js!./src/app/customer/customer/customer.component.html"),
        styles: [__webpack_require__(/*! ./customer.component.css */ "./src/app/customer/customer/customer.component.css")]
    })
], CustomerComponent);



/***/ }),

/***/ "./src/app/customer/order-history/order-history.component.css":
/*!********************************************************************!*\
  !*** ./src/app/customer/order-history/order-history.component.css ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2N1c3RvbWVyL29yZGVyLWhpc3Rvcnkvb3JkZXItaGlzdG9yeS5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/customer/order-history/order-history.component.ts":
/*!*******************************************************************!*\
  !*** ./src/app/customer/order-history/order-history.component.ts ***!
  \*******************************************************************/
/*! exports provided: OrderHistoryComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "OrderHistoryComponent", function() { return OrderHistoryComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _customer_service_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../customer-service.service */ "./src/app/customer/customer-service.service.ts");




let OrderHistoryComponent = class OrderHistoryComponent {
    constructor(route, customerService) {
        this.route = route;
        this.customerService = customerService;
        this.Orders = new Array();
    }
    ngOnInit() {
        this.GetAllorder();
    }
    GetAllorder() {
        const customerId = this.route.parent.snapshot.paramMap.get('customerId');
        this.customerService.GetOrderHistory(customerId).subscribe(res => {
            this.Orders = res;
        }, err => {
            console.log(err);
        });
    }
};
OrderHistoryComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] },
    { type: _customer_service_service__WEBPACK_IMPORTED_MODULE_3__["CustomerServiceService"] }
];
OrderHistoryComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-order-history',
        template: __webpack_require__(/*! raw-loader!./order-history.component.html */ "./node_modules/raw-loader/index.js!./src/app/customer/order-history/order-history.component.html"),
        styles: [__webpack_require__(/*! ./order-history.component.css */ "./src/app/customer/order-history/order-history.component.css")]
    })
], OrderHistoryComponent);



/***/ })

}]);
//# sourceMappingURL=customer-customer-module.js.map