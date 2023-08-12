import { Component, ComponentRef, HostBinding, Input } from '@angular/core';
import { Observable } from 'rxjs';


export type Notification = {
  type: 'success' | 'danger',
  message: string;
}

@Component({
  selector: 'app-notification-message',
  template: `
      {{ notification.message }}
  `,
  styles: [`
    :host {
      display: block;
      margin: .5rem 0;
      padding: .75rem;
      border-radius: .5rem;
    }
    :host.success {
      background-color: #24b145;
    }
    :host.danger {
      background-color: #ef4242;
    }
  `]
})
export class NotificationMessageComponent {
  @Input() notification!: Notification;
  @Input() component!: ComponentRef<NotificationMessageComponent>;
  @HostBinding('class') class!: string;

  constructor() {
  }

  ngOnInit() {
    setTimeout(() => this.component.destroy(), 3000);
  }
}

