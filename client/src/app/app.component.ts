//this file is first being loaded in our browser
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

//it has decorator named Component this represent an angular component , so each web page made up of smaller no of comp, that builts the page
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//insterting lifecycle component inside this component for that we are going to implement OnInit Interface (A life cycle hook)
export class AppComponent implements OnInit {

  title = 'Chirag';
  users: any;

  //httpClient injected into constructor
  constructor(private http: HttpClient) { }

  //implelenting ngOnInit LIFE cycle method

  ngOnInit(): void {

    this.http.get('http://localhost:5143/api/users').subscribe({
      //what happens when we get the data so the function next and then we pass a call back function(lamda function)
      next: response => this.users = response,
      //what we want to do fi there is an error
      error: err => console.log(err),
      //when it completes, and bcs this is an http req it will always complete even if error
      complete: () => console.log('req has completed')
    })

  }
}
