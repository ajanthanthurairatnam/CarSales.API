import { Component } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
    selector:'sandbox',
    template:`
        <h1>Hello World</h1>
        <div *ngFor="let user of users">
            <div class="well">
                <ul class="list-group">
                    <li class="list-group-item">Name: {{ user.FuelType }}</li>
                
                </ul>
                <br>
            </div>
        </div>
    `
})

export class SandboxComponent{
    users:any[];

    constructor(public dataService:DataService)
    {
        this.dataService.getUsers().subscribe(users => {
            //console.log(users);
            this.users = users;
        });
    }
}