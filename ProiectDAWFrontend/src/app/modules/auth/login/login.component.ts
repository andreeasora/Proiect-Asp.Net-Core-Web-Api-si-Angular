import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  public error: string | boolean = false;

  public profileForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private router: Router, 
    private dataService: DataService,) { }
  
  ngOnInit(): void {
  }
  
  public login(): void {
    this.error = false;
    console.log("Register realizat!");
    if (this.validateEmail(this.profileForm.value.username))  
    {
       console.log(this.profileForm.value)
       this.dataService.changeUserData(this.profileForm.value);
       localStorage.setItem('Role', 'Admin');
       this.router.navigate(['/clienti']);
    }
    else
    {
      this.error = "Email-ul introdus nu este valid!";
    }
  }

  validateEmail(email: string) {
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

}
