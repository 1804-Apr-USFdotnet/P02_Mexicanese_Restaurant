import { ChangeDetectionStrategy, Input, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class ItemComponent {

  constructor() { }

  @Input() public id: number;
  @Input() public name: string;
  @Input() public desc: string;
  @Input() public price: number;
  @Input() public quantity: number;

}
