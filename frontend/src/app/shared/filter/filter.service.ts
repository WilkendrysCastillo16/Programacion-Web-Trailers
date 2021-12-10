import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  event: EventEmitter <string> = new EventEmitter <string>();
  constructor() { }
}
