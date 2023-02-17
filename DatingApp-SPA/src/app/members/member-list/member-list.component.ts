import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_Services/alertify.service';
import { UserService } from '../../_Services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  users: User[] = [];

  constructor(private userService: UserService, private alertifyJs: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    /*this.loadUsers();*/
    this.route.data.subscribe(data => {
      this.users = data['users'];
    });
  }

  //loadUsers() {
  //  this.userService.getUsers().subscribe((users: User[]) => {
  //    this.users = users;
  //  }, error => {
  //    this.alertifyJs.error(error);
  //  })
  //}

}
