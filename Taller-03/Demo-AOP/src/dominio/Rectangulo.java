package dominio;

public class Rectangulo {
	private double ancho;
	private double alto;
	
	public Rectangulo() {
	}
	
	public Rectangulo(double lado) {
		this.ancho = lado;
		this.alto = lado;
	}

	public Rectangulo(double ancho, double alto) {
		super();
		this.ancho = ancho;
		this.alto = alto;
	}

	public double getAncho() {
		return ancho;
	}

	public void setAncho(double ancho) {
		this.ancho = ancho;
	}

	public double getAlto() {
		return alto;
	}

	public void setAlto(double alto) {
		this.alto = alto;
	}
	
	public double area() throws DimensionNegativaException {
		if(this.alto < 0 || this.ancho < 0) {
			throw new DimensionNegativaException();
		}
		return this.alto*this.ancho;
	}
	
	public double perimetro() throws DimensionNegativaException {
		if(this.alto < 0 || this.ancho < 0) {
			throw new DimensionNegativaException();
		}
		return (2*this.alto)+(2*this.ancho);
	}
}
