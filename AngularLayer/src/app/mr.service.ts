import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MRService {
  
  constructor(private httpClient: HttpClient) { }

  getMenu(onSuccess){
    var url = "http://ec2-18-188-24-56.us-east-2.compute.amazonaws.com/mexicaneserestaurant/api/menuitem";
    var req = this.httpClient.get(url);
    var promise = req.toPromise();
    promise.then(
      onSuccess,
      (reason) => { console.log(reason) }
    )
  }

}
