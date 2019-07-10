import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    
  public messages: Array<any> = [];             //array for showing the messages
  messageUrl: string = '';

  constructor(public http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.messageUrl = baseUrl;
    this.getData();
  }

  getData()
  {
    let msg = this;
    this.http.request(this.messageUrl + '/api/Data').subscribe((response: Response) => {
      msg.messages = response.json();
    });
  }
}
