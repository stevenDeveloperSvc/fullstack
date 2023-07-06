import { Component, OnInit } from '@angular/core';
import { Tutorial } from 'src/app/models/tutorial.model';
import { TutorialService } from 'src/app/services/tutorial.service';

@Component({
  selector: 'app-add-tutorial',
  templateUrl: './add-tutorial.component.html',
  styleUrls: ['./add-tutorial.component.scss']
})
export class AddTutorialComponent implements OnInit {

  tutorial: Tutorial = {
    username: '',
    email: '',
    passwordHash: '',
    regDate: ' ',
    active : ' '

  };


  user   = {
    id: '',
    email: ''
  }
  submitted = false;


  constructor(private tutorialService: TutorialService) { }

  ngOnInit(): void {
  }

  saveTutorial(): void {
    const data = {
      active: this.tutorial.active,
      email: this.tutorial.email,
      passwordHash : this.tutorial.passwordHash,
      regDate : this.tutorial.regDate,
      username: this.tutorial.username
    };

    this.tutorialService.create(data)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.submitted = true;
        },
        error: (e) => console.error(e)
      });
  }

  newTutorial(): void {
    this.submitted = false;
    this.tutorial = {
      email: '',
      passwordHash: '',
      regDate: '',
      active: ' ',
      username: ''
    };
  }
}
