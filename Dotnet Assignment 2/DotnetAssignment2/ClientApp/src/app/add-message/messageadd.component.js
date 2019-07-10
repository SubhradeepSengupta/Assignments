"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var messageAddComponent = /** @class */ (function () {
    function messageAddComponent(_http, _route, baseUrl) {
        this._http = _http;
        this._route = _route;
        this.message = {};
        this.messageUrl = '';
        this.messageUrl = baseUrl;
    }
    messageAddComponent.prototype.sendData = function () {
        var _this = this;
        this._http.post(this.messageUrl + '/api/Data', this.message).subscribe(function () {
            _this._route.navigate(['/fetch-data']);
        });
    };
    messageAddComponent = __decorate([
        core_1.Component({
            selector: 'add-message',
            templateUrl: './messageadd.component.html'
        }),
        __param(2, core_1.Inject('BASE_URL'))
    ], messageAddComponent);
    return messageAddComponent;
}());
exports.messageAddComponent = messageAddComponent;
//# sourceMappingURL=messageadd.component.js.map