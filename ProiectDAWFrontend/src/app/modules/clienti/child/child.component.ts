import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})

export class ChildComponent implements OnInit {

  @Input() messageFromParent: any;
  @Output() messageFromChild = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
    console.log(this.messageFromParent);
  }

  public emitData(): void{
    this.messageFromChild.emit('mesaj de la copil');
  }
}
