import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router, Data } from "@angular/router";
import { Http, Response } from "@angular/http";

@Component({
  selector: 'message-details',
  templateUrl: './messagedetails.component.html'
})

export class messageDetailsComponent {

  Id: number = 0;
  public messages: Array<any> = [];             //array for showing the messages
  messageUrl: string = '';
  msgs: string = '';

  constructor(private _route: ActivatedRoute, private _router: Router, public _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.messageUrl = baseUrl;
    if (this._route.snapshot.params['id']) {
      this.Id = this._route.snapshot.params['id'];
    }
    this.getData();
  }

  getData() {
    let msg = this;
    if (this.Id > 0) {
      this._http.request(this.messageUrl + '/api/Data/' + this.Id).subscribe((response: Response) => {
        msg.messages = response.json();
        this.msgs = this.messages["comment"];
      });
    }
  }

  increment() {
    this.messages["like"] += 1;
    this._http.put(this.messageUrl + '/api/data/' + this.Id, this.messages).subscribe((response: Response) => {
      this._router.navigate(['/fetch-data']);
    });
  }

  comment(val) {
    if (this.msgs == null) {
      this.messages["comment"] = val;
    }
    else {
      this.messages["comment"] = this.msgs + " || " + val;
    }
    this._http.put(this.messageUrl + '/api/data/' + this.Id, this.messages).subscribe((response: Response) => {
      this._router.navigate(['/fetch-data']);
    });
  }
}
