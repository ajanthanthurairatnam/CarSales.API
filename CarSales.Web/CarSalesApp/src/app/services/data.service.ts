import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService{
    hostUrl='http://localhost:60456/api/';

    constructor(public http:Http){

    }

    getUsers(){
        return this.http.get(this.hostUrl+'VehicleFuels')
            .map(res => res.json());
    }

    getPageSettings(){
        return this.http.get(this.hostUrl+'PageSettings')
            .map(res => res.json());
    }

}