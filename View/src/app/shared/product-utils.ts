export class ProductUtils {
    public CountStars(stars: number): number[] {
        return new Array(stars);
    }

    public FormatName(name: string): string {
        return name.toLocaleLowerCase().split(' ').join('-');
    }

    public PathImage(image: string): string {
        return `/images/${image}`;
    }
}
