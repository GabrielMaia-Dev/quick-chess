import { Component, Input } from '@angular/core';
import { UserModel } from '../../models/UserModel';

@Component({
  selector: 'app-user-tab',
  templateUrl: './user-tab.component.html',
  styleUrls: ['./user-tab.component.scss']
})
export class UserTabComponent {
  @Input({ required: false }) user?: UserModel;
}
