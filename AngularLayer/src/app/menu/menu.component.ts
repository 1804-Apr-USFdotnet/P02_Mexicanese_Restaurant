import { Component, OnInit } from '@angular/core';
import { menuItem } from "../models/menuItem";
import { MRService } from '../mr.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  items: menuItem[];

  constructor(private mrSvc: MRService) { }

  ngOnInit() {
  }

  getMenu(){
    this.mrSvc.getMenu((response) => {
      this.items = response;
    });
  }
}

