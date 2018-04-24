package dominio;

public class Triangulo {
	private double base;
	private double altura;
	
	public Triangulo() {
	}
	
	public Triangulo(double base, double altura) {
		this.base = base;
		this.altura = altura;
	}
	
	public double getBase() {
		return base;
	}
	
	public void setBase(double base) {
		this.base = base;
	}
	
	public double getAltura() {
		return altura;
	}
	
	public void setAltura(double altura) {
		this.altura = altura;
	}
	
	public double area() throws DimensionNegativaException {
		if(this.base < 0 || this.altura < 0) {
			throw new DimensionNegativaException();
		}
		return (this.base*this.altura)/2;
	}
}
