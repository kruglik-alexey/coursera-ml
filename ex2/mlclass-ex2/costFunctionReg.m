function [J, grad] = costFunctionReg(theta, X, y, lambda)
%COSTFUNCTIONREG Compute cost and gradient for logistic regression with regularization
%   J = COSTFUNCTIONREG(theta, X, y, lambda) computes the cost of using
%   theta as the parameter for regularized logistic regression and the
%   gradient of the cost w.r.t. to the parameters. 

% Initialize some useful values
m = length(y); % number of training examples

% You need to return the following variables correctly 
J = 0;
grad = zeros(size(theta));

% ====================== YOUR CODE HERE ======================
% Instructions: Compute the cost of a particular choice of theta.
%               You should set J to the cost.
%               Compute the partial derivatives and set grad to the partial
%               derivatives of the cost w.r.t. each parameter in theta

n = size(theta)(1);
h = sigmoid(X*theta);
ht = h';
y1 = log(ht)*y;
y2 = log(1-ht)*(1-y);
J = -1/m*sum(y1 + y2) + lambda/2/m*sum(theta(2:n, :).^2);
l = ones(n, 1) * lambda;
l(1) = 0;
grad = 1/m*(X')*(h-y) + l.*theta/m;



% =============================================================

end
