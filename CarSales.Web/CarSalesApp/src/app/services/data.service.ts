import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService{
    

    constructor(public http:Http){

    }

    getUsers(){
        return this.http.get('http://localhost:60456/api/VehicleFuels')
            .map(res => res.json());
    }

}