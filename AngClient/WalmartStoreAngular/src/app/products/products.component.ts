import { Component, OnInit } from '@angular/core';
import { Product } from '../product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  product: Product = {
    id: 999,
    name: 'iPhone'
  };
  constructor() { }

  ngOnInit() {
  }
}
