import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Client } from 'src/app/interfaces/client';
import { User } from 'src/app/interfaces/user';
import { ClientiService } from 'src/app/services/clienti.service';
import { DataService } from 'src/app/services/data.service';
import { AdaugaUpdateazaComponent } from '../../modal/adauga-updateaza/adauga-updateaza.component';

@Component({
  selector: 'app-clienti',
  templateUrl: './clienti.component.html',
  styleUrls: ['./clienti.component.scss']
})

export class ClientiComponent implements OnInit, OnDestroy {

  public subscription: Subscription | undefined;
  public loggedUser!: User;
  public parentMessage = 'mesaj de la parinte';
  public clienti : Client[] = [];
  public displayedColumns = ['id' , 'nume', 'telefon', 'adresa', 'delete', 'update', 'profile'];

  constructor(private router: Router,
  private dataService: DataService,
  private clientiSerivice: ClientiService,
  public dialog: MatDialog,) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe((user:User) => this.loggedUser = user);
    this.clientiSerivice.getAllClients().subscribe(
      (result) =>{
        console.log(result);
        this.clienti = result;
        console.log(this.clienti);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnDestroy(): void {
      this.subscription?.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role', 'Anonim');
    this.router.navigate(['/login']);
  }

  public receiveMessage(event: any) : void {
    console.log(event);
  }

  public deleteClient(client: any) : void {
    this.clientiSerivice.deleteClient(client).subscribe(
      (result : Client[]) =>
      {
        console.log(result);
        this.clienti = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public updateClient(client: any) : void {
    this.openModal(client);
  }

  public profileClient(id: any) : void {
    this.router.navigate(['/client', id]);
  }

  public openModal(client?: undefined) : void {
    const data = {
      client
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '650px';
    dialogConfig.data = data;
    const dialogRef = this.dialog?.open(AdaugaUpdateazaComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result)=>
    {
      console.log(result);
      if (result) 
      {
        this.clienti = result;
      }
    });
  }

  public adaugaClient(): void {
    this.openModal();
  }

}
