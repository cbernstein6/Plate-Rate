import { Component, Input } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-school-icon',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './school-icon.component.html',
  styleUrl: './school-icon.component.css'
})
export class SchoolIconComponent {
  @Input() school: any;
  title: string = 'passed title;'

  constructor(private router: Router){
    
  }

}
