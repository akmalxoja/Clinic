import { Component } from '@angular/core';
import { FooterComponent } from "../../static-pages/footer/footer.component";
import { NavbarComponent } from "../../static-pages/navbar/navbar.component";
import { MiniSidebarComponent } from "../../static-pages/mini-sidebar/mini-sidebar.component";

@Component({
    selector: 'app-doctor',
    standalone: true,
    templateUrl: './doctor.component.html',
    styleUrl: './doctor.component.scss',
    imports: [FooterComponent, NavbarComponent, MiniSidebarComponent]
})


export class DoctorComponent {
    private divisor: HTMLElement | null;
    private slider: HTMLInputElement | null;

    constructor() {
        this.divisor = document.getElementById("divisor");
        this.slider = document.getElementById("slider") as HTMLInputElement;

        if (this.slider && this.divisor) {
            this.slider.addEventListener("input", this.moveDivisor.bind(this));
        }
    }

    private moveDivisor(): void {
        if (this.divisor && this.slider) {
            const sliderValue = this.slider.value;
            const widthValue = `${sliderValue}%`; // Set width based on slider value
            this.divisor.style.width = widthValue;
        }
    }
}

// Instantiate the class when the DOM is ready
document.addEventListener("DOMContentLoaded", () => {
    const doctorComponent = new DoctorComponent();
});


