import { Input,Component, OnInit } from '@angular/core';
import {menuItem} from '../models/menuItem';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  public items: menuItem = {itemID:1,itemName:'name',itemDescription:'testdesc',itemPrice:1.00,Stock:2};

  constructor() { }

  ngOnInit() {
  }

}
