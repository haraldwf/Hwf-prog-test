# Hwf linear regression exsample in repeat

data(iris)
res <- lm(Sepal.Length~Petal.Length,data=iris)
summary(res)
plot(iris$Petal.Length,iris$Sepal.Length)
abline(res)