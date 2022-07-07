import { Directive, Input, ElementRef, TemplateRef, ViewContainerRef, OnInit } from '@angular/core';

@Directive({
  selector: '[hasProfile]'
})
export class HasProfileDirective implements OnInit {

  @Input('hasProfile') profile: string;
  allowed: false;

  ngOnInit() {
    if (this.hasPermissions()) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {
      this.viewContainer.clear();
    }
  }

  hasPermissions() : boolean {
    return true;
  }

  updateView() {
    if (this.hasPermissions()) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {
      this.viewContainer.clear();
    }
  }

  constructor(
    private element: ElementRef,
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef) { }

  usuario: any;

}
