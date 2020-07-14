import { TestBed } from '@angular/core/testing';

import { QuizThemeService } from './quiz-theme.service';

describe('QuizThemeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: QuizThemeService = TestBed.get(QuizThemeService);
    expect(service).toBeTruthy();
  });
});
