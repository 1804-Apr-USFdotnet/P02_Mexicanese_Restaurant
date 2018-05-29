import { Input,Component, OnInit } from '@angular/core';
import {menuItem} from '../models/menuItem';
import { ItemComponent } from '../item/item.component';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  public items: ItemComponent[] = [{id:1,name:'name',desc:'testdesc',price:1.00,quantity:2}];

  constructor() { }

  ngOnInit() {
  }

}
