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
var messageDetailsComponent = /** @class */ (function () {
    function messageDetailsComponent(_route, _router, _http, baseUrl) {
        this._route = _route;
        this._router = _router;
        this._http = _http;
        this.Id = 0;
        this.messages = []; //array for showing the messages
        this.messageUrl = '';
        this.msgs = '';
        this.messageUrl = baseUrl;
        if (this._route.snapshot.params['id']) {
            this.Id = this._route.snapshot.params['id'];
        }
        this.getData();
    }
    messageDetailsComponent.prototype.getData = function () {
        var _this = this;
        var msg = this;
        if (this.Id > 0) {
            this._http.request(this.messageUrl + '/api/Data/' + this.Id).subscribe(function (response) {
                msg.messages = response.json();
                _this.msgs = _this.messages["comment"];
            });
        }
    };
    messageDetailsComponent.prototype.increment = function () {
        var _this = this;
        this.messages["like"] += 1;
        this._http.put(this.messageUrl + '/api/data/' + this.Id, this.messages).subscribe(function (response) {
            _this._router.navigate(['/fetch-data']);
        });
    };
    messageDetailsComponent.prototype.comment = function (val) {
        var _this = this;
        if (this.msgs == null) {
            this.messages["comment"] = val;
        }
        else {
            this.messages["comment"] = this.msgs + " || " + val;
        }
        this._http.put(this.messageUrl + '/api/data/' + this.Id, this.messages).subscribe(function (response) {
            _this._router.navigate(['/fetch-data']);
        });
    };
    messageDetailsComponent = __decorate([
        core_1.Component({
            selector: 'message-details',
            templateUrl: './messagedetails.component.html'
        }),
        __param(3, core_1.Inject('BASE_URL'))
    ], messageDetailsComponent);
    return messageDetailsComponent;
}());
exports.messageDetailsComponent = messageDetailsComponent;
//# sourceMappingURL=messagedetails.component.js.map