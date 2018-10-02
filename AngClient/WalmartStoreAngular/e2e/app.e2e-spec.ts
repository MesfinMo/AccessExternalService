import { WalmartStoreAngularPage } from './app.po';

describe('walmart-store-angular App', () => {
  let page: WalmartStoreAngularPage;

  beforeEach(() => {
    page = new WalmartStoreAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
