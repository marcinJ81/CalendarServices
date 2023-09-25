import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class formatMethod {
  formatTime(inputTime: string): string {
    const parts = inputTime.split(":");
    let hours = parts[0];
    let minutes = parts[1];
  
   
    hours = this.padWithZero(hours);
    minutes = this.padWithZero(minutes);
  
    return `${hours}:${minutes}`;
  }

  padWithZero(value: string): string {
  return value.length === 1 ? `0${value}` : value;
  }
}

