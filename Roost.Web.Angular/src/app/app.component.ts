import { Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { HttpClient } from '@angular/common/http';
import { FooterComponent } from './shared/footer/footer.component';
import { HeaderComponent } from './shared/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit {

  isSmallScreen = false;
  isXtraSmallScreen = false;

  constructor(private responsive: BreakpointObserver) {
  }

  ngOnInit(): void {

    this.responsive.observe(Breakpoints.Small).subscribe(x => {
      this.isSmallScreen = x.matches;
    });

    this.responsive.observe(Breakpoints.XSmall).subscribe(x => {
      this.isXtraSmallScreen = x.matches;
    });
  }
}
