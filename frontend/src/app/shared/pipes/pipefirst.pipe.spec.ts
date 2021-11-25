import { PipefirstPipe } from './pipefirst.pipe';

describe('PipefirstPipe', () => {
  it('create an instance', () => {
    const pipe = new PipefirstPipe();
    expect(pipe).toBeTruthy();
  });
});
