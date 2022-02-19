import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHoverBtn]'
})
export class HoverBtnDirective {

  constructor(
    private el: ElementRef,
  ) { }

  @HostListener('mouseenter') onMouseEnter(){
    this.highlight('cyan');
  }

  @HostListener('mouseleave') onMouseLeave(){
    this.highlight('');
  }

  private highlight(color: string){
    this.el.nativeElement.style.backgroundColor = color;
  }
}
