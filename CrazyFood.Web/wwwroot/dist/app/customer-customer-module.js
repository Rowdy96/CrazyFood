(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["customer-customer-module"],{

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/customer-followers/customer-followers.component.html":
/*!*********************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/customer-followers/customer-followers.component.html ***!
  \*********************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"panel\">\r\n  <div>\r\n    <table class=\"table-striped\">\r\n      <thead>\r\n        <tr>\r\n          <th> Name</th>\r\n          <th> </th>\r\n        </tr>\r\n      </thead>\r\n      <tbody>\r\n        <tr *ngFor=\"let follower of AllFollowers\">\r\n          <td>{{follower.FollowedUser.Email}}</td>\r\n          <td><button class=\"btn btn-primary\" type=\"button\" (click)=\"OnClick(follower.FollowedUser.Id)\">Unfollow</button></td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/customer-review/customer-review.component.html":
/*!***************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/customer-review/customer-review.component.html ***!
  \***************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container col-md-12\">\r\n  <h2>Reviews</h2>\r\n  <div *ngFor=\"let review of ReviewList\">\r\n\r\n    <div class=\"panel panel-primary\">\r\n      <div class=\"panel-body\">\r\n        <h4><a>{{review.RestaurantName}}</a></h4>\r\n        <h5>Rated:{{review.Rating}}/ 5</h5>\r\n        <h5>Review: {{review.ReviewText}}</h5>\r\n\r\n        <div>\r\n          <a (click)=\"addLike(review)\">\r\n            <span class=\"glyphicon glyphicon-thumbs-up\" style=\"font-size:40px;\"></span>\r\n          </a>\r\n          {{review.totalLike}}\r\n          <a (click)=\"toggle(review)\">\r\n            <span class=\"glyphicon glyphicon-comment\" style=\"font-size:40px;\"></span>\r\n          </a>\r\n          {{review.TotalComment}}\r\n        </div>\r\n      </div>\r\n      <div *ngIf=\"review.showComment\">\r\n        <div *ngIf=\"review.reviewCommnets\">\r\n          <div *ngFor=\"let comment of review.reviewCommnets\">\r\n            <div class=\"panel panel-primary\">\r\n              <div class=\"panel-heading\">{{comment.UserName}}</div>\r\n              <div class=\"panel-body\">\r\n                <h5>{{comment.ReviewCommentText}}</h5>\r\n              </div>\r\n            </div>\r\n          </div>\r\n        </div>\r\n      </div>\r\n\r\n      <div>\r\n        <form [formGroup]=\"commentForm\" (ngSubmit)=\"addComment(review.reviewId)\">\r\n          <div class=\"input-group\">\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"Write Comment\" formControlName=\"commentText\">\r\n            <div class=\"input-group-btn\">\r\n              <button class=\"btn btn-success\" type=\"submit\">\r\n                Add Comment\r\n              </button>\r\n            </div>\r\n          </div>\r\n        </form>\r\n      </div>\r\n\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/customer/customer.component.html":
/*!*************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/customer/customer.component.html ***!
  \*************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"panel panel-primary\">\r\n    <div class=\"panel-heading\">{{User.Name}}</div>\r\n    <div class=\"panel-body\">\r\n      <h5>Phone: {{User.Phone}}</h5>\r\n      <h5>Email: {{User.Email}}</h5>\r\n      <h5>Address: {{User.Address}}</h5>\r\n      <button *ngIf=\"!IsFollowed\" class=\"btn btn-primary\" (click)=\"FollowUser(User.Id)\">Follow</button>\r\n      <button *ngIf=\"IsFollowed\" class=\"btn btn-primary\" (click)=\"UnFollowUser(User.Id)\">UnFollow</button>\r\n    </div>\r\n    <div class=\"panel-footer\">\r\n      <div class=\"btn-group btn-group-justified\">\r\n        <div class=\"btn-group\">\r\n          <a class=\"btn btn-primary\" routerLink=\"Reviews\">Reviews</a>\r\n        </div>\r\n        <div class=\"btn-group\" >\r\n          <a class=\"btn btn-primary\" routerLink=\"Followers\"> Followers</a>\r\n        </div>\r\n        <div class=\"btn-group\" *ngIf=\"customerId==loggedInUserId\">\r\n          <a class=\"btn btn-primary\" routerLink=\"OrderHistory\"> Order history</a>\r\n        </div>\r\n      </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"panel panel-primary\">\r\n   <div class=\"panel-body\">\r\n      <router-outlet></router-outlet>\r\n   </div>\r\n</div>\r\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/customer/order-history/order-history.component.html":
/*!***********************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/customer/order-history/order-history.component.html ***!
  \***********************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div *ngFor=\"let order of Orders\">\r\n  <div class=\"panel panel-primary\">\r\n    <div class=\"panel-heading\"> Order Id : {{order.OrderId}} </div>\r\n    <div class=\"panel-body\">\r\n      <div class=\"panel panel-title\">\r\n        <label>Restaurant Name : </label> {{order.RestaurantName}}\r\n      </div>\r\n      <table class=\"table table-striped\">\r\n        <thead>\r\n          <tr>\r\n            <th>Dish Name</th>\r\n            <th>Item Count</th>\r\n            <th>Dish Price</th>\r\n            <th>Menu Category</th>\r\n          </tr>\r\n        </thead>\r\n        <tbody>\r\n          <tr *ngFor=\"let item of order.OrderItem\">\r\n            <td>{{item.DishName}}</td>\r\n            <td>{{item.ItemCount}}</td>\r\n            <td>{{item.Price}}</td>\r\n            <td>{{item.MenuCategoryName}}</td>\r\n          </tr>\r\n        </tbody>\r\n      </table>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/Models/FollowAC.ts":
/*!************************************!*\
  !*** ./src/app/Models/FollowAC.ts ***!
  \************************************/
/*! exports provided: FollowAC */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FollowAC", function() { return FollowAC; });
class FollowAC {
}


/***/ }),

/***/ "./src/app/customer/customer-followers/customer-followers.component.css":
/*!******************************************************************************!*\
  !*** ./src/app/customer/customer-followers/customer-followers.component.css ***!
  \******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2N1c3RvbWVyL2N1c3RvbWVyLWZvbGxvd2Vycy9jdXN0b21lci1mb2xsb3dlcnMuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/customer/customer-followers/customer-followers.component.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/customer/customer-followers/customer-followers.component.ts ***!
  \*****************************************************************************/
/*! exports provided: CustomerFollowersComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerFollowersComponent", function() { return CustomerFollowersComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _customer_service_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../customer-service.service */ "./src/app/customer/customer-service.service.ts");
/* harmony import */ var _Models_FollowAC__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../Models/FollowAC */ "./src/app/Models/FollowAC.ts");
/* harmony import */ var _user_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../user.service */ "./src/app/user.service.ts");






let CustomerFollowersComponent = class CustomerFollowersComponent {
    constructor(route, service, userService) {
        this.route = route;
        this.service = service;
        this.userService = userService;
    }
    ngOnInit() {
        this.GetAllFollowers();
    }
    GetAllFollowers() {
        const customerId = this.route.parent.snapshot.paramMap.get('customerId');
        this.service.GetFollowersOfUser(customerId).subscribe(res => {
            this.AllFollowers = res;
            console.log(res);
        }, err => {
            alert("Error");
        });
    }
    OnClick(userId) {
        var unfollow = new _Models_FollowAC__WEBPACK_IMPORTED_MODULE_4__["FollowAC"]();
        unfollow.FollowingUserId = this.userService.currentUser.Id;
        unfollow.FollowedUserId = userId;
        this.service.UnFollowUser(unfollow).subscribe(res => {
            this.ngOnInit();
            alert("Success");
        }, err => {
            alert("Error");
        });
    }
};
CustomerFollowersComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] },
    { type: _customer_service_service__WEBPACK_IMPORTED_MODULE_3__["CustomerServiceService"] },
    { type: _user_service__WEBPACK_IMPORTED_MODULE_5__["UserService"] }
];
CustomerFollowersComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-customer-followers',
        template: __webpack_require__(/*! raw-loader!./customer-followers.component.html */ "./node_modules/raw-loader/index.js!./src/app/customer/customer-followers/customer-followers.component.html"),
        styles: [__webpack_require__(/*! ./customer-followers.component.css */ "./src/app/customer/customer-followers/customer-followers.component.css")]
    })
], CustomerFollowersComponent);



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
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _customer_service_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../customer-service.service */ "./src/app/customer/customer-service.service.ts");
/* harmony import */ var _user_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../user.service */ "./src/app/user.service.ts");
/* harmony import */ var _Models_ReviewLike__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../Models/ReviewLike */ "./src/app/Models/ReviewLike.ts");
/* harmony import */ var _Models_UserAC__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../Models/UserAC */ "./src/app/Models/UserAC.ts");
/* harmony import */ var _add_review_review_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../add-review/review.service */ "./src/app/add-review/review.service.ts");
/* harmony import */ var _Models_Comment__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../Models/Comment */ "./src/app/Models/Comment.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");










let CustomerReviewComponent = class CustomerReviewComponent {
    constructor(route, customerService, userService, reviewService) {
        this.route = route;
        this.customerService = customerService;
        this.userService = userService;
        this.reviewService = reviewService;
        this.user = new _Models_UserAC__WEBPACK_IMPORTED_MODULE_6__["UserAC"]();
        this.comment = new _Models_Comment__WEBPACK_IMPORTED_MODULE_8__["Comment"]();
        this.commentForm = new _angular_forms__WEBPACK_IMPORTED_MODULE_9__["FormGroup"]({
            commentText: new _angular_forms__WEBPACK_IMPORTED_MODULE_9__["FormControl"]('')
        });
    }
    ngOnInit() {
        this.GetReview();
        this.user = this.userService.currentUser;
    }
    GetReview() {
        const customerId = this.route.parent.snapshot.paramMap.get('customerId');
        this.customerService.GetReviewsOfUser(customerId).subscribe(res => {
            this.ReviewList = res;
            console.log(this.ReviewList);
        }, err => {
            alert("Error");
        });
    }
    toggle(review) {
        if (!review.ShowComment) {
            review.ShowComment = true;
        }
        else {
            review.ShowComment = false;
        }
    }
    addLike(review) {
        if (this.user == null) {
            alert("You are not Logged In");
        }
        else {
            var like = new _Models_ReviewLike__WEBPACK_IMPORTED_MODULE_5__["ReviewLike"]();
            like.ReviewId = review.ReviewId;
            like.UserId = this.user.Id;
            this.reviewService.AddLike(like, like.ReviewId).subscribe(res => {
                alert("Like Added");
                window.location.reload();
            }, err => {
                alert("Error");
            });
        }
    }
    addComment(reviewId) {
        if (this.user == null) {
            alert("You are not Logged In");
        }
        else {
            this.comment.CommentText = this.commentForm.value.commentText;
            this.comment.ReviewId = reviewId;
            this.comment.UserId = this.user.Id;
            this.reviewService.AddComment(this.comment, reviewId).subscribe(res => {
                console.log("success");
                window.location.reload();
            }, err => {
                console.log("error");
            });
        }
    }
};
CustomerReviewComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"] },
    { type: _customer_service_service__WEBPACK_IMPORTED_MODULE_3__["CustomerServiceService"] },
    { type: _user_service__WEBPACK_IMPORTED_MODULE_4__["UserService"] },
    { type: _add_review_review_service__WEBPACK_IMPORTED_MODULE_7__["ReviewService"] }
];
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
/* harmony import */ var _customer_followers_customer_followers_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./customer-followers/customer-followers.component */ "./src/app/customer/customer-followers/customer-followers.component.ts");







const routes = [
    {
        path: '',
        component: _customer_customer_component__WEBPACK_IMPORTED_MODULE_3__["CustomerComponent"],
        children: [
            {
                path: '',
                component: _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_4__["CustomerReviewComponent"]
            },
            {
                path: 'Reviews',
                component: _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_4__["CustomerReviewComponent"]
            },
            {
                path: 'Followers',
                component: _customer_followers_customer_followers_component__WEBPACK_IMPORTED_MODULE_6__["CustomerFollowersComponent"]
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
    GetReviewsOfUser(userId) {
        return this.http.get('https://localhost:44303/api/Reviews/GetReviewsOfUser/' + userId);
    }
    GetFollowersOfUser(userId) {
        return this.http.get('https://localhost:44303/api/Follow/ListOfFollowersOfUser/' + userId);
    }
    IsFollowedByCurrentUser(followingId, followedId) {
        var url = 'https://localhost:44303/api/Follow/IsFollowing/' + followedId + '/' + followingId;
        debugger;
        return this.http.get(url);
    }
    FollowUser(follow) {
        var url = "https://localhost:44303/api/Follow/FollowUser";
        return this.http.post(url, follow);
    }
    UnFollowUser(follow) {
        var url = "https://localhost:44303/api/Follow/UnFollowUser";
        return this.http.put(url, follow);
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
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var _customer_followers_customer_followers_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./customer-followers/customer-followers.component */ "./src/app/customer/customer-followers/customer-followers.component.ts");









let CustomerModule = class CustomerModule {
};
CustomerModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [_customer_customer_component__WEBPACK_IMPORTED_MODULE_4__["CustomerComponent"], _customer_review_customer_review_component__WEBPACK_IMPORTED_MODULE_5__["CustomerReviewComponent"], _order_history_order_history_component__WEBPACK_IMPORTED_MODULE_6__["OrderHistoryComponent"], _customer_followers_customer_followers_component__WEBPACK_IMPORTED_MODULE_8__["CustomerFollowersComponent"]],
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"],
            _customer_routing_module__WEBPACK_IMPORTED_MODULE_3__["CustomerRoutingModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_7__["ReactiveFormsModule"]
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
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _Models_FollowAC__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../Models/FollowAC */ "./src/app/Models/FollowAC.ts");
/* harmony import */ var _customer_service_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../customer-service.service */ "./src/app/customer/customer-service.service.ts");







let CustomerComponent = class CustomerComponent {
    constructor(userSerVice, route, customerService) {
        this.userSerVice = userSerVice;
        this.route = route;
        this.customerService = customerService;
        this.User = new src_app_Models_UserAC__WEBPACK_IMPORTED_MODULE_3__["UserAC"]();
        this.followUser = new _Models_FollowAC__WEBPACK_IMPORTED_MODULE_5__["FollowAC"]();
    }
    ngOnInit() {
        this.customerId = this.route.snapshot.paramMap.get('customerId');
        if (this.userSerVice.currentUser == null) {
            this.GetUser();
            debugger;
        }
        else {
            this.loggedInUserId = this.userSerVice.currentUser.Id;
            if (this.loggedInUserId == this.customerId) {
                this.User = this.userSerVice.currentUser;
            }
            else {
                this.GetUser();
            }
        }
    }
    GetUser() {
        this.userSerVice.GetUserDetails(this.customerId).subscribe(res => {
            this.User = res;
            this.customerService
                .IsFollowedByCurrentUser(this.User.Id, this.userSerVice.currentUser.Id)
                .subscribe(res => { this.IsFollowed = res; }, err => { alert("Error"); });
        });
    }
    FollowUser(userId) {
        this.followUser.FollowingUserId = userId;
        this.followUser.FollowedUserId = this.loggedInUserId;
        this.customerService.FollowUser(this.followUser).subscribe(res => {
            this.followUser = res;
            this.ngOnInit();
        }, err => {
            alert("Error");
        });
    }
    UnFollowUser(UserId) {
        var unfollow = new _Models_FollowAC__WEBPACK_IMPORTED_MODULE_5__["FollowAC"]();
        unfollow.FollowingUserId = this.loggedInUserId;
        unfollow.FollowedUserId = UserId;
        this.customerService.UnFollowUser(unfollow).subscribe(res => {
            this.ngOnInit();
        }, err => {
            alert("Error");
        });
    }
};
CustomerComponent.ctorParameters = () => [
    { type: src_app_user_service__WEBPACK_IMPORTED_MODULE_2__["UserService"] },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__["ActivatedRoute"] },
    { type: _customer_service_service__WEBPACK_IMPORTED_MODULE_6__["CustomerServiceService"] }
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
            console.log(this.Orders);
            debugger;
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