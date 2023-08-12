import { Component, ViewChild, ViewContainerRef } from '@angular/core';
import { NotificationService } from '../../services/notification.service';
import { Notification, NotificationMessageComponent } from './notification-message.component';


@Component({
  selector: 'app-notification-container',
  template: `
  <ng-template #container></ng-template>
  `,
  styles: [`
  :host {
    display: block;
    width: 100%;
    position: absolute;
    top: 0;
    padding: 0 20px;
  }
  `]
})
export class NotificationContainerComponent {
  @ViewChild('container', { static: true, read: ViewContainerRef }) container!: ViewContainerRef;
  notifications: Notification[] = [];

  constructor(public service: NotificationService) { }

  ngOnInit(): void {
    this.service.getMessages().subscribe(notification => {
      const component = this.container.createComponent(NotificationMessageComponent);
      component.instance.class = notification.type;
      component.setInput('component', component);
      component.setInput('notification', notification);
    });
  }
}
