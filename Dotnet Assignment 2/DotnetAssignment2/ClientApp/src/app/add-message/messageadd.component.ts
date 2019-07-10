import { Component, Inject } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";
import { Router } from "@angular/router";


@Component({
  selector: 'add-message',
  templateUrl: './messageadd.component.html'
})

export class messageAddComponent {

  message: any = {};
  messageUrl: string = '';

  constructor(public _http: Http, private _route: Router, @Inject('BASE_URL') baseUrl: string) {
    this.messageUrl = baseUrl;
  }

  sendData(): void {
    this._http.post(this.messageUrl + '/api/Data', this.message).subscribe(() => {
      this._route.navigate(['/fetch-data']);
    });
  }
}
