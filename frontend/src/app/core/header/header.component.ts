import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { 
  }


  ngOnInit(): void {

    const toggleButton = document.getElementsByClassName('toggle-button')[0]
    const navbarActive = document.getElementsByClassName('navbar-links')[0]

    
    toggleButton.addEventListener('click', () => {
      navbarActive.classList.toggle('active')
    })


  }

}
