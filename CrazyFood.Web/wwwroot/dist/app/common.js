(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["common"],{

/***/ "./src/app/Models/Comment.ts":
/*!***********************************!*\
  !*** ./src/app/Models/Comment.ts ***!
  \***********************************/
/*! exports provided: Comment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Comment", function() { return Comment; });
class Comment {
}


/***/ }),

/***/ "./src/app/Models/ReviewLike.ts":
/*!**************************************!*\
  !*** ./src/app/Models/ReviewLike.ts ***!
  \**************************************/
/*! exports provided: ReviewLike */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReviewLike", function() { return ReviewLike; });
class ReviewLike {
}


/***/ }),

/***/ "./src/app/add-review/review.service.ts":
/*!**********************************************!*\
  !*** ./src/app/add-review/review.service.ts ***!
  \**********************************************/
/*! exports provided: ReviewService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReviewService", function() { return ReviewService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");



let ReviewService = class ReviewService {
    constructor(http) {
        this.http = http;
        this.rootUrl = "https://localhost:44303/";
    }
    AddReview(review, restaurantId) {
        var url = this.rootUrl + "api/Reviews/AddReviw/" + restaurantId;
        debugger;
        return this.http.post(url, review);
        debugger;
    }
    AddComment(comment, reviewId) {
        var url = this.rootUrl + "api/Reviews/AddComment/" + reviewId;
        debugger;
        return this.http.post(url, comment);
    }
    AddLike(like, reviewId) {
        var url = this.rootUrl + "api/Reviews/AddLike/" + reviewId;
        debugger;
        return this.http.post(url, like);
    }
};
ReviewService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"] }
];
ReviewService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
    })
], ReviewService);



/***/ })

}]);
//# sourceMappingURL=common.js.map