import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Client } from 'src/app/interfaces/client';
import { ClientiService } from 'src/app/services/clienti.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  public subscription: Subscription | undefined;
  public id: any;
  public client : Client = {
    nume: '',
    telefon: '',
    id: 0,
  }
  constructor(
    private route: ActivatedRoute,
    private clientsService: ClientiService,) { }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params =>
      {
        this.id = +params['id'];
        if (this.id) {
          this.getClient();
        }
      });
  }

  public getClient():void{
      this.clientsService.getClientById(this.id).subscribe(
         (result : Client) => {
           console.log(result);
           this.client = result;
         },
         (error) => {
           console.log(error);
         }
      );
  }

}
