package app;

import dominio.Circulo;
import dominio.DimensionNegativaException;
import dominio.Rectangulo;
import dominio.Triangulo;

public class Principal {

	public static void main(String[] args) {
		try {
			Circulo c = new Circulo(5);
			System.out.println("Soy un círculo de radio " + c.getRadio());
			Rectangulo r = new Rectangulo(7,8);
			System.out.println("Soy un rectángulo de ancho " + r.getAncho() + " y de alto " + r.getAlto());
			Triangulo t = new Triangulo(9,10);
			System.out.println("Soy un triángulo de base " + t.getBase() + " y de altura " + t.getAltura());
			System.out.println("Soy un círculo de área " + c.area());
			System.out.println("Soy un rectángulo de área " + r.area());
			System.out.println("Soy un triángulo de área " + t.area());
			System.out.println("Soy un círculo de perímetro " + c.perimetro());
			System.out.println("Soy un rectángulo de perímetro " + r.perimetro());
			Circulo k = new Circulo(-4);
			System.out.println("Soy un círculo de radio " + k.getRadio());
			System.out.println("Soy un círculo de área " + k.area());
		} catch (DimensionNegativaException e) {
			System.out.println(e.getMessage());
		}
	}
}
