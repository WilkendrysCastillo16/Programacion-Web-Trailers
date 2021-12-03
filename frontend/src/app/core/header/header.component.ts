import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  emailAdmin = localStorage.getItem("Email"); 
  constructor(private router:Router) { 
  }

  ngOnInit(): void {
    const toggleButton = document.getElementsByClassName('toggle-button')[0]
    const navbarActive = document.getElementsByClassName('navbar-links')[0]

    toggleButton.addEventListener('click', () => {
      navbarActive.classList.toggle('active')
    })

  }

  exists(){
    if(localStorage.getItem("Token")){
      return false;
    }
    else{
      return true;
    }

  }


}
