package dominio;

public class Circulo {
	private double radio;
	
	public Circulo() {
	}

	public Circulo(double radio) {
		this.radio = radio;
	}

	public double getRadio() {
		return radio;
	}

	public void setRadio(double radio) {
		this.radio = radio;
	}
	
	public double area() throws DimensionNegativaException {
		if(this.radio < 0) {
			throw new DimensionNegativaException();
		}
		return Math.PI*this.radio*this.radio;
	}
	
	public double perimetro() throws DimensionNegativaException {
		if(this.radio < 0) {
			throw new DimensionNegativaException();
		}
		return 2*Math.PI*this.radio;
	}
}
