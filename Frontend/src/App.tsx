import { Component } from 'react'
import Footer from './components/Footer';
import Header from './components/Header';
import Categories from './components/Categories';
import Catalog from './components/Catalog';
import Product from './objects/Product';
import ProductCategory from './objects/ProductCategory';

interface AppState {
  dataIsLoaded: boolean
  orders: Product[]
  categories: ProductCategory[]
  currentProducts: Product[]
  products: Product[]
}

class App extends Component<any, AppState> {

  constructor(props: any) {
    super(props)

    this.state = {
      dataIsLoaded: false,
      orders: [],
      categories: [],
      currentProducts: [],
      products: []
    }

    this.addToOrder = this.addToOrder.bind(this)
    this.deleteFromOrder = this.deleteFromOrder.bind(this)
    this.chooseCategory = this.chooseCategory.bind(this)
  }

  componentDidMount() {
    let apiURL: string = process.env.REACT_APP_API_URL as string;

    fetch(apiURL + "categories")
      .then((res) => res.json())
      .then((json) => {
        this.setState({ categories: json })
      });

      fetch(apiURL + "products")
      .then((res) => res.json())
      .then((json) => {
        this.setState({ products: json })
        this.setState({ currentProducts: json })
      });

    this.setState({ dataIsLoaded: true });
  }

  render() {
    if (!this.state.dataIsLoaded) {
      return (
        <div>Загрузка данных...</div>
      );
    }
    return (
      <div className="wrapper">
        <Header orders={this.state.orders} onDeleteFromOrder={this.deleteFromOrder} />
        <Categories categories={this.state.categories} chooseCategory={this.chooseCategory} />
        <Catalog products={this.state.currentProducts} onAdd={this.addToOrder} />
        <Footer />
      </div>
    );
  }

  addToOrder(product: Product) {
    let isInArray = false;

    this.state.orders.forEach(i => {
      if (i.id === product.id) {
        isInArray = true;
      }
    })

    if (!isInArray)
      this.setState({ orders: [...this.state.orders, product] })
  }

  deleteFromOrder(id: number) {
    this.setState({ orders: this.state.orders.filter(i => i.id !== id) })
  }

  chooseCategory(categoryId: number) {
    if (categoryId === 0) {
      this.setState({ currentProducts: this.state.products })
      return
    }

    this.setState({ currentProducts: this.state.products.filter(i => i.category.id === categoryId) })
  }
}

export default App;
