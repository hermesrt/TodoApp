import { TestBed } from '@angular/core/testing';

import { TodoGroupService } from './todo-group.service';

describe('TodoGroupService', () => {
  let service: TodoGroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TodoGroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
